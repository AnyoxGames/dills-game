13
4715874091009
405066411992984 1761863336543730000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 2.8709576129913330,
    "Y": -11.7793493270874023
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405057757590460:1761863334527245700",
  "next_sibling": "405068415344968:1761863337010513100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405066412227936:1761863336543784000",
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
  "aoid": "405066412353969:1761863336543813300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405066412227936:1761863336543784000",
    "DefaultRenderer": "405066412402215:1761863336543824600",
    "DepletedRenderer": "405066412385746:1761863336543820700"
  }
},
{
  "cid": 5,
  "aoid": "405066412366611:1761863336543816300",
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
