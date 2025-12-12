13
4672924418049
405056469312180 1761863334227075000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 10.2467966079711914,
    "Y": -12.1641750335693359
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405053894836089:1761863333627220100",
  "next_sibling": "405057757590460:1761863334527245700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405056469570567:1761863334227134500",
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
  "aoid": "405056469693848:1761863334227163200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405056469570567:1761863334227134500",
    "DefaultRenderer": "405056469743986:1761863334227175000",
    "DepletedRenderer": "405056469727904:1761863334227171200"
  }
},
{
  "cid": 5,
  "aoid": "405056469707393:1761863334227166500",
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
