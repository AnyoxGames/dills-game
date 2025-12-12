13
3964254814209
404955754513689 1761863310760423000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -7.3269405364990234,
    "Y": -9.9193563461303711
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404954323786862:1761863310427062000",
  "next_sibling": "404958258315413:1761863311343811400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404955754770614:1761863310760481900",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404955754899528:1761863310760511900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404955754770614:1761863310760481900",
    "DefaultRenderer": "404955754950225:1761863310760523700",
    "DepletedRenderer": "404955754933713:1761863310760519900"
  }
},
{
  "cid": 5,
  "aoid": "404955754914148:1761863310760515300",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
