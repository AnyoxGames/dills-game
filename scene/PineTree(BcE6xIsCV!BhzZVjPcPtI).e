13
3985729650689
404958258315413 1761863311343811400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -9.1869354248046875,
    "Y": -10.1759071350097656
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404955754513689:1761863310760423000",
  "next_sibling": "404959689068001:1761863311677178100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404958258721333:1761863311343905000",
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
  "aoid": "404958258864910:1761863311343938500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404958258721333:1761863311343905000",
    "DefaultRenderer": "404958258939773:1761863311343955900",
    "DepletedRenderer": "404958258912640:1761863311343949600"
  }
},
{
  "cid": 5,
  "aoid": "404958258885034:1761863311343943100",
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
